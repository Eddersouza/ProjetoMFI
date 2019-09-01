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
                        <p className="lead">Você pode procurar orçamentos:</p>
                        <ul className="list-unstyled" style={{ lineHeight: "2" }}>
                            <li><FontAwesomeIcon className="text-success" icon="check" />&nbsp;
                              Fazer Orçamentos para sua festa
                             </li>
                            {/* <li><FontAwesomeIcon className="text-success" icon="check" />&nbsp;
                              Escolher seus  fornecedores favoritos
                              </li>
                            <li><FontAwesomeIcon className="text-success" icon="check" />&nbsp;
                              Avaliar os fornecedores  cadastrados
                              </li> */}
                        </ul>
                    </Col>
                </Row>
                <Row>
                    <Col md={12} className="text-center">
                        <Button type="button" outline color="primary" size="lg" block>
                            <FontAwesomeIcon className="text-primary" icon={["far","hand-point-right"]} />&nbsp;
                                Entre aqui
                        </Button>
                    </Col>
                </Row>
            </CardBody>
        </Card>
    );
}

export default UserTypeChooseProvider