import React, { useState, useEffect } from 'react';
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
import FingerprintIcon from '@material-ui/icons/Fingerprint';

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
        id: '',
        idLabel: 'ID пользователя',
        idError: '',
    });

    const handleChange = prop => event => {
        setValues({ ...values, [prop]: event.target.value });
        if (prop == 'id') {
            var pattern = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;
            if (!pattern.test(String(event.target.value).toLowerCase())) {
                setValues({ ...values, ['idLabel']: 'Ошибка ID', ['idError']: 'Некорректный ID', [prop]: event.target.value });
            } else {
                setValues({ ...values, ['idLabel']: 'ID', ['idError']: '', [prop]: event.target.value });
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

    function SuccessAlert(props) {
        return (<div className={classes.errorCenter}>
            <Alert severity="success">{props.message}</Alert>
        </div>)
    }
    function InfoAlert(props) {
        return (<div className={classes.errorCenter}>
            <Alert severity="info">{props.message}</Alert>
        </div>)
    }

    function ConfirmBtn(props) {
        const [result, setCount] = useState({ success: false, errors: [] });

        const handleConfirm = () => {
            let params = {
                userId: values.id,
            };
            axios.get(`/api/Account/ConfirmUser?userId=${values.id}`)
                .then(function (res) {
                    console.log(res.data)
                    var message = ''
                    if (res.data.message)
                        message = res.data.message
                    setCount({ success: res.data.success, errors: [message] })
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
                    <Button variant="contained" color="primary" onClick={handleConfirm} className={classes.marginButton} disabled={!values.emailError == ''}>
                        Подтвердить
                </Button>
                </div>
                {result.success
                    ? <div>
                        <div className={classes.errorCenter}>
                            <SuccessAlert message={"Новый пользователь создан."} />
                        </div>
                        <div className={classes.errorCenter}>
                            <InfoAlert message={'Пользователю назначена роль "Пользователь".'} />
                        </div>
                    </div>
                    :
                    <div className={classes.errorCenter}>
                        <ErrorAlert errors={result.errors} />
                    </div>
                }
            </div>
        );
    }

    function GetUsers(props) {
        const [result, setCount] = useState({ success: false, errors: [] });

        const handleConfirm = () => {
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
                    var message = ''
                    if (res.data.message)
                        message = res.data.message
                    setCount({ success: res.data.success, errors: [message] })
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
                    <Button variant="contained" color="primary" onClick={handleConfirm} className={classes.marginButton} disabled={!values.emailError == ''}>
                        Подтвердить
                </Button>
                </div>
                {result.success
                    ? <div>
                        <div className={classes.errorCenter}>
                            <SuccessAlert message={"Новый пользователь создан."} />
                        </div>
                        <div className={classes.errorCenter}>
                            <InfoAlert message={'Пользователю назначена роль "Пользователь".'} />
                        </div>
                    </div>
                    :
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
                    <div className={classes.root}>{"Подтверждение пользователя"}</div>
                    <div className={classes.inputCenter}>
                        <Grid container spacing={1} className={classes.inputCenter}>
                            <Grid item>
                                <TextField id="id-field" label={values.idLabel} onChange={handleChange('id')} helperText={values.idError} />
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <FingerprintIcon />
                            </Grid>
                        </Grid>
                    </div>
                    <ConfirmBtn />
                </div>
            </div>
        </div>
    );
}

