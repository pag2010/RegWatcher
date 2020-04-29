import React, { useState } from 'react';
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
import {
    Redirect
} from 'react-router-dom'

export default function Registration() {

    const useStyles = makeStyles(theme => ({
        alignItemsAndJustifyContent: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            height: '100%',
        },
        fillWindowContent: {
            position: 'absolute',
            height: '85%',
            width: '95%',
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

    const [values, setValues] = React.useState({
        password: '',
        showPassword: false,
        email: '',
        errors: [],
    });

    const handleChange = prop => event => {
        setValues({ ...values, [prop]: event.target.value });
    };

    const handleClickShowPassword = () => {
        setValues({ ...values, showPassword: !values.showPassword });
    };

    const handleMouseDownPassword = event => {
        event.preventDefault();
    };


    function ErrorAlert(props) {
        let alerts = []
        for (var i in props.errors) {
            alerts.push(
                <div className={classes.errorCenter}>
                    <Alert severity="error">{props.errors[i]}</Alert>
                </div>
            )
        }
        if (props.errors.length > 0 || props.errors != null)
            if (props.errors.length)
                return alerts
            else
                return <div />
        else
            return <div />
    }

    function LoginBtn(props) {
        const [result, setCount] = useState({ success: false, errors: [] });

        const handleLogin = () => {
            let params = {
                email: values.email,
                password: values.password,
                rememberMe: false
            };
            axios.post('/api/Account/Login', params)
                .then(function (res) {
                    console.log(res.data)
                    setCount({ success: res.data.success, errors: [res.data.message] })
                })
                .catch(function (err) {
                    console.log(err.response.data)
                    var messages = []
                    if (err.response.data.length) {
                        for (var i in err.response.data) {
                            messages.push(err.response.data[i].errorMessage)
                        }
                    } else {
                        messages.push(err.response.data.message)
                    }
                    setCount({ success: false, errors: messages })
                });
        }
        return (
            <div>
                <div className={classes.divCenter}>
                    <Button variant="contained" color="primary" onClick={handleLogin} className={classes.marginButton}>
                        Войти
                </Button>
                </div>
                {result.success &&
                    <Redirect to={"/Home/"} />
                }
                {result.errors != null &&
                    <div className={classes.errorCenter}>
                        <ErrorAlert errors={result.errors} />
                    </div>
                }
            </div>
        );
    }


    return (
        <div className={classes.fillWindowContent}>
            <div className={classes.alignItemsAndJustifyContent}>
                <div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField
                                    
                                    id="email-field"
                                    label="Error"
                                    defaultValue="Hello World"
                                    helperText="Incorrect entry."
                                    onChange={handleChange('email')}
                                />
                                <TextField id="email-field" label="Email" onChange={handleChange('email')} />
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <AccountCircle />
                            </Grid>
                        </Grid>
                    </div>
                    <div className={classes.inputCenter}>
                        <TextField
                            id="outlined-adornment-password"
                            type={values.showPassword ? 'text' : 'password'}
                            label="Пароль"
                            value={values.password}
                            onChange={handleChange('password')}
                            InputProps={{
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton
                                            edge="end"
                                            aria-label="toggle password visibility"
                                            onClick={handleClickShowPassword}
                                            onMouseDown={handleMouseDownPassword}
                                        >
                                            {values.showPassword ? <VisibilityOff /> : <Visibility />}
                                        </IconButton>
                                    </InputAdornment>
                                ),
                            }}
                        />
                    </div>
                    <LoginBtn />
                </div>
            </div>
        </div>
    );
}
