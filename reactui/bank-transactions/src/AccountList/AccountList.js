import React, { useState, useEffect } from 'react';
import { Paper } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import ListItem from '@material-ui/core/ListItem';
import List from '@material-ui/core/List'
import CircularProgress from '@material-ui/core/CircularProgress'
import axios from 'axios';
import AccountTransactions from '../AccountTransactions/AccountTransactions';

const useStyles = makeStyles((theme) => ({
    paper: {
        padding: 10,
        margin: 10
    },
    accountName: {
        flex: '33.33333%',
        textAlign: 'center'
    },
    accountNumber: {
        flex: '33.33333%'
    },
    balance: {
        flex: '33.33333%',
        textAlign: 'right'
    },
    accountList: {
        display: 'flex',
    }
}));

export default function AccountList() {
    const [isLoading, setLoading] = useState(true);
    const [accounts, setAccounts] = useState([]);
    const [selectedIndex, setSelectedIndex] = useState(0);
    const [selectedAccountNumber, setSelectedAccountNumber] = useState(null);
    const classes = useStyles();

    const handleAccountClick = (event, index) => {
        setSelectedIndex(index);
        setSelectedAccountNumber(accounts[index].accountName);
        console.log(event, accounts[index].accountName);
    };

    useEffect(() => {
        async function GetAccounts() {
            setLoading(true);
            const response = await axios.get("api/accounts");
            setAccounts(response.data);
            setLoading(false);
        }
        GetAccounts();
    }, []);

    const accountList = accounts.map((item, i) =>
        <ListItem
            button
            className={classes.accountList}
            selected={selectedIndex === i}
            onClick={(event) => handleAccountClick(event, i)}
            key={i}>
            <div className={classes.accountNumber}>{item.nickName}</div>
            <div className={classes.accountName}>{item.accountName}</div>
            <div className={classes.balance}>{item.balance}</div>
        </ListItem>
    );

    if (isLoading) {
        return (
            <Paper className={classes.paper}>
                <CircularProgress color="secondary" />
            </Paper>
        );
    }
    else {
        return (
            <div>
                <Paper className={classes.paper}>
                    <List>
                        {accountList}
                    </List>
                </Paper>
                <Paper className={classes.paper}>
                    <AccountTransactions accountName={selectedAccountNumber} />
                </Paper>
            </div>
        );
    }
}