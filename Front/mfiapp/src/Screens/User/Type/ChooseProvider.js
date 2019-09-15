import React from 'react'
import {
    Card,
    CardBody,
    Row,
    Col,
    Button
} from 'reactstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const UserTypeChooseProvider = () => {
    return (
        <Card>
            <CardBody>
                <Row>
                    <Col md={12}>                     
                        <p className="lead">Você pode oferecer orçamentos:</p>
                        <ul className="list-unstyled" style={{ lineHeight: "2" }}>
                            <li>
                                <FontAwesomeIcon className="text-success" icon="check" />&nbsp;
                                Mostre seus serviços
                            </li>
                            {/* <li>
                                <FontAwesomeIcon className="text-success" icon="check" />&nbsp;
                                Mostre suas promoções
                            </li> */}
                        </ul>
                    </Col>
                </Row>
                <Row>
                    <Col md={12} className="text-center">
                        <Button type="button" outline color="secondary" size="lg" block>
                            <FontAwesomeIcon className="text-secondary" icon={["far","hand-point-right"]} />&nbsp;
                                Entre aqui
                        </Button>
                    </Col>
                </Row>
            </CardBody>
        </Card>
    );
}

export default UserTypeChooseProvider