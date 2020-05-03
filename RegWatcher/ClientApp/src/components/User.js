import React from 'react';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import Button from '@material-ui/core/Button';
import PropTypes from 'prop-types';
import HowToRegIcon from '@material-ui/icons/HowToReg';
import Alert from '@material-ui/lab/Alert';

export default function User(props) {
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
            marginTop: '2%',
            display: 'flex',
        },
        divCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
        },
        userCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center'
        },
        errorCenter: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            marginTop: '5%'
        },
        alertMargin: {
            display: 'flex',
            marginTop: '2%',
            marginBottom: '2%',
        },
        modal: {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
        },
        paper: {
            backgroundColor: theme.palette.background.paper,
            border: '2px solid #000',
            boxShadow: theme.shadows[5],
            padding: theme.spacing(2, 4, 3),
        },
        modalButton: {
            display: 'flex',
            marginTop: '5%'
        },
        divFles: {
            display: 'flex',
            flexDirection: 'row',
        }
    }));
    const classes = useStyles();
    

    function TransitionsModal(props) {
        const classes = useStyles();
        const [open, setOpen] = React.useState(false);

        const handleOpen = () => {
            setOpen(true);
        };

        const handleClose = () => {
            setOpen(false);
        };

        return (
            <div>
                <Button color="primary" onClick={handleOpen}>
                    {props.name}
                </Button>
                <Modal
                    aria-labelledby="transition-modal-title"
                    aria-describedby="transition-modal-description"
                    className={classes.modal}
                    open={open}
                    onClose={handleClose}
                    closeAfterTransition
                    BackdropComponent={Backdrop}
                    BackdropProps={{
                        timeout: 500,
                    }}
                >
                    <Fade in={open}>
                        <div className={classes.paper}>
                            <h2 id="transition-modal-title">{props.name}</h2>
                            <p id="user-id">ID: {props.id}</p>
                            <p id="user-email">Email: {props.email}</p>
                            {props.isEmailConfirmed
                                ? <div className={classes.alertMargin}> <Alert severity="success">Email подтверждён</Alert> </div>
                                : <div className={classes.alertMargin}> <Alert severity="warning">Email не подтверждён</Alert> </div>
                            }
                            {props.confirmedByUserId 
                                ? <div className={classes.alertMargin}> <Alert severity="success">Пользователь активирован с учётной записи: {props.confirmedByUserId}</Alert> </div>
                                : <div>
                                    <div className={classes.alertMargin}> <Alert severity="warning">Пользователь не активирован</Alert> </div>
                                    <Button className={classes.marginButton} variant='outlined' color='primary' startIcon={< HowToRegIcon />}>Активировать пользователя</Button>
                                </div>
                                }
                            <p id="user-roles">Назначенные роли:</p>
                            {props.roles.length>0 
                                ?<ul>
                                    {props.roles.map((role) => <li>{role}</li>)}
                                </ul>
                                : <div>
                                    <div className={classes.alertMargin}> <Alert severity="warning">Пользователю не назначены роли</Alert> </div>
                                    <Button className={classes.marginButton} variant='outlined' color='primary' startIcon={< HowToRegIcon />}>Назначить роль</Button>
                                </div>
                            }
                        </div>
                    </Fade>
                </Modal>
            </div>
        );
    }

    return (
        <div>
        

        <div className={classes.modalButton}>
                <TransitionsModal name={props.Name} email={props.Email} id={props.Id}
                    isEmailConfirmed={props.isEmailConfirmed} confirmedByUserId={props.confirmedByUserId}
                    roles={props.roles}></TransitionsModal>
            </div>

        </div>
    )
}
