import React, { useContext, Fragment } from "react"
import { RootStoreContext } from "../../app/stores/rootStore"
import {Container, Row, Col, Button} from "react-bootstrap";
import '../../index.scss';
import { Link } from "react-router-dom";

const HomePage = () => {
    const rootStore = useContext(RootStoreContext);
    const {isLoggedIn, user} = rootStore.userStore;

    return (
        <Fragment>
            <div className='home-page'>
                <Container>
                    <Row>
                        <Col>
                            <img src='/assets/logo.png' className='logo'/>
                            <Button variant="primary" as={Link} to='/dashboard'></Button>
                        </Col>
                    </Row>
                    <Row>
                    {isLoggedIn && user ? (
                        <Col>                                                      
                            <h1>Welcome back {user.username}</h1>
                        </Col>
                    ) : (
                             <Col></Col>
                    )
                            
                            }
                       
                    </Row>
                    <Row>
                        
                    </Row>
                </Container>
            </div>
            
        </Fragment>
    );
};

export default HomePage;