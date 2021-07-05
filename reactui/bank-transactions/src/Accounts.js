import React from 'react';
import axios from 'axios';

class Accounts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    axios.get("http://localhost:7071/api/accounts")
      .then(res => {
        this.setState({
          isLoaded: true,
          items: res.data
        })
      })
  };


  render() {
    const { error, isLoaded, items } = this.state;
    const options = items.map((i) => 
      <option value="{i}">{i}</option>
    );
    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
        <select name="accounts">
          {options}
        </select>
      );
    }
  }

}

export default Accounts;