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
import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import InputAdornment from '@material-ui/core/InputAdornment';
import FormControl from '@material-ui/core/FormControl';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import AccountCircle from '@material-ui/icons/AccountCircle';

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
    }
}));

export default function InputWithIcon() {
    const classes = useStyles();

    return (
        <div className={classes.fillWindowContent}>
            <div className={classes.alignItemsAndJustifyContent}>
                <div>
                    <div>
                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <AccountCircle />
                            </Grid>
                            <Grid item>
                                <TextField id="email-field" label="Email" />
                            </Grid>
                        </Grid>
                    </div>
                    <div>
                        <Grid container spacing={1} alignItems="flex-end" position="flex">
                            <Grid item>
                                <AccountCircle />
                            </Grid>
                            <Grid item>
                                <TextField id="email-field" label="Password" />
                            </Grid>
                        </Grid>
                        </div>
                   </div>
            </div>
        </div>
    );
}