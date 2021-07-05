import React from 'react';
import axios from 'axios';

class Identity extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoaded: false,
    };
  }


  componentDidMount() {
    axios.get("/.auth/me")
      .then(res => {
        this.setState({
          user: res.data.userDetails,
          isLoaded: true
        })
      })
  };


  render() {
    if (this.state.isLoaded) {
      if (this.state.user) {
        return <div>Hello, {this.state.user}</div>;
      }
      else {
        return (
          <div>
            <a href="/.auth/login/github">Login</a>
          </div>
        );
      }
    }
    else {
      return <div>Loading...</div>;
    }

  }
}

export default Identity;