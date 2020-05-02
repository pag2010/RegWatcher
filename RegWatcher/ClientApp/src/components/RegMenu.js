import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { makeStyles } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import List from '@material-ui/core/List';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import MailIcon from '@material-ui/icons/Mail';
import { Link } from 'react-router-dom';
import MeetingRoomIcon from '@material-ui/icons/MeetingRoom';
import HomeIcon from '@material-ui/icons/Home';
import { Container } from 'reactstrap';
import MenuItem from '@material-ui/core/MenuItem';
import Menu from '@material-ui/core/Menu';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import WorkIcon from '@material-ui/icons/Work';
import HowToRegIcon from '@material-ui/icons/HowToReg';
import axios from 'axios';
import {
    Redirect
} from 'react-router-dom'

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
    },
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
    },
    drawer: {
        width: drawerWidth,
        flexShrink: 0,
    },
    drawerPaper: {
        width: '15%',
    },
    drawerContainer: {
        overflow: 'auto',
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
    },
    container: {
        padding: 0
    }
}));

const options = [
    'Функции управления',
    <ListItem button component={Link} to="/Account/Registration">
        <ListItemIcon> <PersonAddIcon /> </ListItemIcon>
        <ListItemText primary='Регистрация пользователя' />
    </ListItem>,
    <ListItem button component={Link} to="/Account/ConfirmUser">
        <ListItemIcon> <HowToRegIcon /> </ListItemIcon>
        <ListItemText primary='Подтверждение пользователя' />
    </ListItem>,
    'Hide sensitive notification content',
    'Hide all notification content',
];


export default function RegMenu(props) {
    const classes = useStyles();
    const [loginPage, changeState] = useState(true);
    const [anchorEl, setAnchorEl] = useState(null);
    const [selectedIndex, setSelectedIndex] = React.useState(1);
    const [requestStatus, setRequestStatus] = useState(0);
    const [roles, setRoles] = useState([]);
    const [location, setLocation] = useState('');

    

    const connectOpen = async () => {
        var res = 0;
        try {
            var kek = await axios.get('/api/Account/GetMyRoles')
        }
        catch (ex) {
            console.log('err')
        }
        //res = kek.status;
        setRequestStatus(200)
    }


    useEffect(() => {
        var r = window.location.pathname
        setLocation(r);
        //connectOpen()
        if (requestStatus == 0 )
            axios.get('/api/Account/GetMyRoles')
                .then(function (res) {
                    setRequestStatus(200)
                    var rroles = res.data
                    setRoles(rroles);
                    //console.log(roles)
                })
                .catch(function (err) {
                    if (err.response.status == 401)
                        setRequestStatus(err.response.status)
                    if (err.response.status == 400)
                        setRequestStatus(err.response.status)
                    if (err.response.status == 404)
                        setRequestStatus(401)
                })
                .then(function (data) {
                    console.log(data)
                });
        switch (requestStatus) {
            case 0:
            case 401:
                console.log("Ошибка авторизации")
                break;
            case 400:
                console.log("Неизвестная ошибка")
                break;
            case 200:
                console.log("Ошибок нет")
                break;
        }
    }, []);

    const handleClickManagement = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    const handleMenuItemClick = (event, index) => {
        setSelectedIndex(index);
        setAnchorEl(null);
    };

    return (
        <div className={classes.root}>
            {(requestStatus == 401 && location != "/Account/Login") &&
                <Redirect to={"/Account/Login"} />
            }
                <div>
                <CssBaseline />
                {location != "/Account/Login" && (requestStatus == 200 || requestStatus == 0) &&
                    <Drawer
                        className={classes.drawer}
                        variant="permanent"
                        classes={{
                            paper: classes.drawerPaper,
                        }}
                    >
                    <Toolbar />
                        <div className={classes.drawerContainer}>
                        <List>
                            {roles.includes('Administrator') &&
                                <div>
                                <ListItem
                                    button
                                    aria-haspopup="true"
                                    aria-controls="lock-menu"
                                    onClick={handleClickManagement}>
                                    <ListItemIcon> <WorkIcon /> </ListItemIcon>
                                    <ListItemText primary='Управление' />
                                </ListItem>
                                <Menu
                                    id="lock-menu"
                                    anchorEl={anchorEl}
                                    keepMounted
                                    open={Boolean(anchorEl)}
                                    onClose={handleClose}
                                >
                                    {options.map((option, index) => (
                                        <MenuItem
                                            key={option}
                                            disabled={index === 0}
                                            selected={index === selectedIndex}
                                            onClick={(event) => handleMenuItemClick(event, index)}
                                        >
                                            {option}
                                        </MenuItem>
                                    ))}
                                </Menu>
                                </div>
                            }
                            </List>
                            <Divider />
                        <List>
                            <ListItem button component={Link} to="/Home">
                                <ListItemIcon> <HomeIcon /> </ListItemIcon>
                                <ListItemText primary='Домой' />
                            </ListItem>
                            <ListItem button component={Link} to="/Account/Login">
                                <ListItemIcon> <MeetingRoomIcon /> </ListItemIcon>
                                    <ListItemText primary='Выход' />
                            </ListItem>
                            </List>
                        </div>
                </Drawer>
                }
                    <main className={classes.content}>
                    <Toolbar />
                    {
                        <Container className={classes.container}>
                            {props.children}
                        </Container>
                    }
                    </main>
                </div>
            
        </div>
    );
}
