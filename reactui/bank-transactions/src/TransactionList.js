import React from 'react';
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import axios from 'axios';

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine-dark.css';

class TransactionList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      account: props.account,
      items: []
    };
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevProps.account !== this.props.account) {
      axios.get(`api/${this.props.account}/transactions`)
        .then(res => {
          this.setState({
            isLoaded: true,
            items: res.data
          })
        })
    }
  };

  setCategory(item) {
    axios.post(`api/${item.id}/transactioncategory`, item)
      .then(res => {
        console.log(res);
      });
  };

  render() {
    const { error, isLoaded, items } = this.state;
    const columnTypes = {
      editableColumn: { editable: true, singleClickEdit: true },
      dateColumn: {
        filter: 'agDateColumnFilter',
        suppressMenu: true
      }
    };
    const categorySetter = (event) => {
      console.log(event);
      event.data.category = event.newValue;
      this.setCategory({ id: event.data.id, category: event.newValue });
      return true
    };

    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
        <div id="transactionGrid" className="ag-theme-alpine-dark" style={{ height: 400, width: '100%' }}>
          <AgGridReact
            defaultColDef={{
              flex: 1,
              sortable: true,
              filter: true,
            }}
            columnTypes={columnTypes}
            rowData={items}>
            <AgGridColumn field="id" hide="true"></AgGridColumn>
            <AgGridColumn field="transactionDate" type="dateColumn"></AgGridColumn>
            <AgGridColumn field="description"></AgGridColumn>
            <AgGridColumn field="amount" filter="agNumberColumnFilter"></AgGridColumn>
            <AgGridColumn field="category" type="editableColumn" valueSetter={categorySetter}></AgGridColumn>
          </AgGridReact>
        </div>
      );
    }
  }

}

export default TransactionList;