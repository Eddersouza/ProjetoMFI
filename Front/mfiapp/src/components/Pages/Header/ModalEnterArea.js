import React from 'react';
import {
    Button,
    Modal,
    ModalHeader,
    ModalBody,
    Row, Col,
    Form,
    FormGroup,
    Label,
    Input,
} from 'reactstrap';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const ModalEnterArea = (props) => {
    return (
        <Modal isOpen={props.modalOpen} toggle={props.toggle} className='primary' backdrop='static' style={{ maxWidth: '70%' }}>
            <ModalHeader toggle={props.toggle}>O que voce deseja?</ModalHeader>
            <ModalBody>
                <Row>
                    <Col md={6} sm={12}>
                        <p className="lead">Entrar no sistema: </p>
                        <div className="well">
                            <Form id="loginForm" noValidate="novalidate">
                                <FormGroup>
                                    <Label for="username" className="control-label">Email</Label>
                                    <Input type="text" className="form-control" id="username" name="username"
                                        title="Digite o seu email" placeholder="meuemail@gmail.com" />
                                    <span className="help-block"></span>
                                </FormGroup>
                                <FormGroup>
                                    <Label for="password" className="control-label">Senha</Label>
                                    <Input type="password" className="form-control" id="password" name="password"
                                        title="Digite sua Senha" />
                                    <span className="help-block"></span>
                                </FormGroup>
                                <Button type="submit" className="btn btn-success btn-block">Entrar</Button>
                                <a href="/forgot/" className="btn btn-default btn-block">Esqueci a senha</a>
                            </Form>
                        </div>
                    </Col>
                    <Col md={6} sm={12}>
                        <p className="lead">Registrar no sistema </p>
                        <ul className="list-unstyled" style={{ lineHeight: '2' }}>
                            <li><FontAwesomeIcon className="text-success" icon="check" /> Faça Orcamentos</li>
                            {/* <li><FontAwesomeIcon className="text-success" icon="check" />Escolha seus fornecedores favoritos
                                </li>
                            <li><FontAwesomeIcon className="text-success" icon="check" />Avalie os fornecedores cadastrados
                                </li> */}
                        </ul>
                        Ou
                            <ul className="list-unstyled" style={{ lineHeight: '2' }}>
                            <li><FontAwesomeIcon className="text-success" icon="check" />Mostre seus serviços</li>
                            <li><FontAwesomeIcon className="text-success" icon="check" />Mostre suas promoções</li>
                        </ul>
                        <p><button className="btn btn-info btn-block">Sim quero me
                                    registrar</button></p>
                    </Col>
                </Row>
            </ModalBody>
        </Modal>
    );
}

export default ModalEnterArea;