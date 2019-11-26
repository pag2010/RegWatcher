/*import React from 'react';
import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';

const Login = props => (
    <div>
        <Button variant="contained" color="primary">
            Войти
        </Button>
    </div>
);

export default connect()(Login);*/
import React, { useEffect } from 'react';
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
import axios from 'axios'

export default function Login() {

    const useStyles = makeStyles(theme => ({
        alignItemsAndJustifyContent: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            height: '100%',
        },
        fillWindowContent: {
            position: 'absolute',
            height: '80%',
            width: '80%',
        },
        marginIcon: {
            marginLeft: '5%',
        },
        marginButton: {
            marginTop: '5%',
        },
        divCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
        }
    }));

    const classes = useStyles();

    const [values, setValues] = React.useState({
        password: '',
        showPassword: false,
        email: '',
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

     var handleLogin = useEffect(() => {
            axios.post('/api/Account/Login', JSON.parse('{ "email": "values.email", "password": "values.password" }'))
                .then(function (res) {
                    alert('you win')
                })
                .catch(function (err) {
                    alert(err)
                });
        })

    return (
        <div className={classes.fillWindowContent}>
            <div className={classes.alignItemsAndJustifyContent}>
                <div>
                    <div>
                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <TextField id="email-field" label="Email" onChange={handleChange('email')}/>
                            </Grid>
                            <Grid item className={classes.marginIcon}>
                                <AccountCircle />
                            </Grid>
                        </Grid>
                    </div>
                    <div>
                        <TextField
                            id="outlined-adornment-password"
                            type={values.showPassword ? 'text' : 'password'}
                            label="Password"
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
                    <div className={classes.divCenter}>
                        <Button variant="contained" color="primary" onClick={handleLogin} className={classes.marginButton}>
                            LogIn
                        </Button>
                    </div>
                </div>
            </div>
        </div>
    );
}