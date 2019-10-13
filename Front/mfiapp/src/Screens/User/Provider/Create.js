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

import UserProviderFormNew from '../../../components/User/Provider/Forms/New'

const UserProviderCreatePage = (props) => {
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
                            Novo Fornecedor
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
                            <UserProviderFormNew /> 
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </>)
}

export default withRouter(UserProviderCreatePage)