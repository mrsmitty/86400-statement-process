import axios from 'axios';
import { useState, useEffect } from 'react';
import CircularProgress from '@material-ui/core/CircularProgress'
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine-dark.css';


const columnTypes = {
    editableColumn: { editable: true, singleClickEdit: true },
    dateColumn: {
        filter: 'agDateColumnFilter',
        suppressMenu: true
    }
};

const setCategory = async (event) => {
    try {
        if (event.data.category !== event.newValue) {
            const result = await axios.post(`api/${event.data.id}/transactioncategory`, event.newValue);
            event.data.category = event.newValue;
            console.log(result);
        }
        else {
            console.log(`not changed ${event.newValue}`);
        }
        return true
    }
    catch (err) {
        console.error(err);
        return false;
    }
};

export default function AccountTransactions(accountNumber) {
    const [isLoading, setLoading] = useState(true);
    const [transactions, setTransactions] = useState([]);

    useEffect(() => {
        console.log(accountNumber);
        async function GetTransactions() {
            setLoading(true);
            const response = await axios.get(`api/${accountNumber}/transactions`);
            setTransactions(response.data);
            setLoading(false);
        }
        GetTransactions();
    }, []);


    if (isLoading) {
        return <CircularProgress color="secondary" />
    }
    else {
        if (transactions.length === 0) {
            return <span>error</span>
        }
        else {
            return (
                <div id="transactionGrid" className="ag-theme-alpine-dark" style={{ height: 400, width: '100%' }}>
                    <AgGridReact
                        defaultColDef={{
                            flex: 1,
                            sortable: true,
                            filter: true,
                        }}
                        columnTypes={columnTypes}
                        rowData={transactions}>
                        <AgGridColumn field="id" hide="true"></AgGridColumn>
                        <AgGridColumn field="transactionDate" type="dateColumn"></AgGridColumn>
                        <AgGridColumn field="description"></AgGridColumn>
                        <AgGridColumn field="amount" filter="agNumberColumnFilter"></AgGridColumn>
                        <AgGridColumn field="category" type="editableColumn" valueSetter={setCategory}></AgGridColumn>
                    </AgGridReact>
                </div>
            );
        }
    }
}