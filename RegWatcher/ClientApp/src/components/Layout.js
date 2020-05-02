import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import RegMenu from './RegMenu';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';



export default function Layout(props) {

    const useStyles = makeStyles((theme) => ({
        root: {
            display: 'flex',
        },
        appBar: {
            zIndex: theme.zIndex.drawer + 1,
        }
    }));
    const classes = useStyles();

    return (

        <div>
            <AppBar position="fixed" className={classes.appBar}>
                <Toolbar>
                    <Typography variant="h6" noWrap>
                        RegWatcher
          </Typography>
                </Toolbar>
            </AppBar>
            <RegMenu children={props.children}>
            
            </RegMenu>
        </div>
    );
}
