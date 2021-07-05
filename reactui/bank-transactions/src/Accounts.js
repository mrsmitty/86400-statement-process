import React from 'react';
import axios from 'axios';
import TransactionList from './TransactionList';

class Accounts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: [],
      value: ''
    };
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(event) {
    this.setState({value: event.target.value});
  }

  componentDidMount() {
    axios.get("api/accounts")
      .then(res => {
        this.setState({
          isLoaded: true,
          items: res.data,
          value: res.data[0]
        })
      })
  };


  render() {
    const { error, isLoaded, items } = this.state;
    const options = items.map((i) => 
      <option value={i}>{i}</option>
    );
    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
        <div>
          <select value={this.state.value} onChange={this.handleChange}>
            {options}
          </select>
          <TransactionList account={this.state.value} />
        </div>
      );
    }
  }

}

export default Accounts;