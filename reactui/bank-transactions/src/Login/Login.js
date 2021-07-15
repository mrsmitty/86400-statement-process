import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/core'

const useStyles = makeStyles((theme) => ({
  icon: {
    width: 24,
    height: 24,
    margin: 5
  }
}));

export default function Login() {
  const [user, setUser] = useState(null);
  const classes = useStyles();

  useEffect(() => {
    async function auth() {
      const res = await axios.get("/.auth/me");
      console.log(res);
      if (res.status === 200) {
        setUser(res.data.clientPrincipal.userDetails);
      }
    }
    auth();
  }, []);


  if (user) {
    return <div>Hello, {user}</div>;
  }
  else {
    return (
      <Button href="/.auth/login/github"><img className={classes.icon} alt="" src="/GitHub-Mark-Light-32px.png"></img>Login</Button>
    );
  }
}