import React from 'react'
import {
    Card,
    CardHeader,
    CardBody,
    Col,
    Row
} from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

import UserRequesterFormNew from '../../../components/User/Requester/Forms/New';

const UserRequesterCreatePage = () => {
    return (
        <>
            <Row>
                &nbsp;
            </Row>
            <Row>
                <Col md={12}>
                    <Card>
                        <CardHeader>
                            <FontAwesomeIcon icon="reply" title="Voltar" />&nbsp;
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

export default UserRequesterCreatePage