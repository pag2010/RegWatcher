import React from 'react';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import InputAdornment from '@material-ui/core/InputAdornment';
import FormControl from '@material-ui/core/FormControl';
import Grid from '@material-ui/core/Grid';
import AccountCircle from '@material-ui/icons/AccountCircle';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import Visibility from '@material-ui/icons/Visibility';
import VisibilityOff from '@material-ui/icons/VisibilityOff';
import IconButton from '@material-ui/core/IconButton';
import Button from '@material-ui/core/Button';
import axios from 'axios';
import Alert from '@material-ui/lab/Alert';
import ContactMailIcon from '@material-ui/icons/ContactMail';
import {
    Redirect
} from 'react-router-dom';

export default function Home() {
    const useStyles = makeStyles(theme => ({
        root: {
            ...theme.typography.button,
            padding: theme.spacing(1),
        },
        alignItemsAndJustifyContent: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            height: '100%',
        },
        fillWindowContent: {
            position: 'absolute',
            height: '85%',
            width: '80%',
            marginLeft: '15%'
        },
        marginIcon: {
            marginLeft: '5%',
        },
        marginButton: {
            marginTop: '5%',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
        },
        divCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
        },
        inputCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center'
        },
        errorCenter: {
            //display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            marginTop: '5%'
        }
    }));
    const classes = useStyles();
    return (
        <div className={classes.fillWindowContent}>
            <div className={classes.alignItemsAndJustifyContent}>
                <div>
                    <div className={classes.inputCenter}>
                        <div className={classes.root}>{"Добро пожаловать в систему!"}</div>
                    </div>
                </div>
            </div>
        </div>)
        }
