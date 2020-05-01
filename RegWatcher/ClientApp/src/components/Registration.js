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
        firstName: '',
        secondName: '',
        lastName: '',
        confirmPassword: '',
        errors: [],
        emailLabel: 'Email',
        emailError: ''
    });

    const handleChange = prop => event => {
        setValues({ ...values, [prop]: event.target.value });
        if (prop == 'email') {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!re.test(String(event.target.value).toLowerCase())) {
                setValues({ ...values, ['emailLabel']: 'Ошибка email', ['emailError']: 'Некорректный email', [prop]: event.target.value});
            }
            else {
                setValues({ ...values, ['emailLabel']: 'Email', ['emailError']: '', [prop]: event.target.value });
            }
        }
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

    function RegBtn(props) {
        const [result, setCount] = useState({ success: false, errors: [] });

        const handleLogin = () => {
            let params = {
                email: values.email,
                password: values.password,
                confirmPassword: values.confirmPassword,
                firstName: values.firstName,
                secondName: values.secondName,
                lastName: values.lastName,
                rememberMe: false
            };
            axios.post('/api/Account/Registration', params)
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
                    <Button variant="contained" color="primary" onClick={handleLogin} className={classes.marginButton} disabled={!values.emailError == ''}>
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
                    <div className={classes.root}>{"Регистрация нового пользователя"}</div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField id="email-field" label={values.emailLabel} onChange={handleChange('email')} helperText={values.emailError}/>
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <AccountCircle />
                            </Grid>
                        </Grid>
                    </div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField id="firstName-field" label="Имя" onChange={handleChange('firstName')} />
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <AccountCircle />
                            </Grid>
                        </Grid>
                    </div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField id="secondName-field" label="Фамилия" onChange={handleChange('secondName')} />
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <AccountCircle />
                            </Grid>
                        </Grid>
                    </div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField id="lastName-field" label="Отчество" onChange={handleChange('lastName')} />
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
                    <div className={classes.inputCenter}>
                        <TextField
                            id="outlined-adornment-password"
                            type={values.showPassword ? 'text' : 'password'}
                            label="Подтверждение пароля"
                            value={values.confirmPassword}
                            onChange={handleChange('confirmPassword')}
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
                    <RegBtn />
                </div>
            </div>
        </div>
    );
}
