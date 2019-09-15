import React from 'react'
import {
    Card,
    CardHeader,
    CardBody,
    Col,
    Row
} from 'reactstrap';
import { withRouter } from 'react-router-dom';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

import UserRequesterFormNew from '../../../components/User/Requester/Forms/New';

const UserRequesterCreatePage = (props) => {
    const returnLastPage = () => {
        props.history.goBack();
    }
    return (
        <>
            <Row>
                &nbsp;
            </Row>
            <Row>
                <Col md={12}>
                    <Card>
                        <CardHeader>
                            <button className='btn' onClick={returnLastPage}>
                                <FontAwesomeIcon icon="reply" title="Voltar" />&nbsp;
                            </button>
                            Novo Cliente
                        </CardHeader>
                    </Card>
                </Col>
            </Row>
            <Row>
                &nbsp;
            </Row>
            <Row>
                <Col md={12}>
                    <Card>
                        <CardBody>
                            <UserRequesterFormNew />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </>)
}

export default withRouter(UserRequesterCreatePage)