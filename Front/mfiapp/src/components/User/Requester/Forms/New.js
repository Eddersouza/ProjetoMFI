import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

import {
    Button,
    FormGroup,
    Label,
    Input,
    Row,
    Col
} from 'reactstrap';

const UserRequesterFormNew = () => {
    const [email, setEmail] = useState("")
    const [name, setName] = useState("")
    const [password, setPassword] = useState("")


    const handleSubmit = (event) => {
        event.preventDefault();

        const data = {
            Email: email,
            Name: name,
            Password: password
        }

        console.log(data)
    }
    return (
        <form onSubmit={handleSubmit}>
            <Row>
                <Col md={12}>
                    <FormGroup>
                        <Label for="txtEmail">Email</Label>
                        <Input id="txtEmail"
                            name="email"
                            onChange={e => setEmail(e.target.value)}
                            placeholder="Digite um email"
                            type="email"
                            value={email} />
                    </FormGroup>
                </Col>
            </Row>
            <Row>
                <Col md={12}>
                    <FormGroup>
                        <Label for="txtName">Nome</Label>
                        <Input id="txtName"
                            name="name"
                            onChange={e => setName(e.target.value)}
                            placeholder="Digite o nome"
                            type="name"
                            value={name} />
                    </FormGroup>
                </Col>
            </Row>
            <Row>
                <Col md={6}>
                    <FormGroup>
                        <Label for="txtPassword">Senha</Label>
                        <Input id="txtPassword"
                            name="password"
                            onChange={e => setPassword(e.target.value)}
                            placeholder="Digite sua senha"
                            type="password"
                            value={password} />
                    </FormGroup>
                </Col>
                <Col md={6}>
                    <FormGroup>
                        <Label for="txtPassword">Confirme a Senha</Label>
                        <Input type="password" name="passwordConfirm" id="txtPasswordConfirm" placeholder="Digite sua senha" />
                    </FormGroup>
                </Col>
            </Row>
            <Row>
                <Col md={12}>
                    <FormGroup>
                        <Button className="button180" color="danger" title="Cancelar Criação de Cliente">
                            <FontAwesomeIcon icon="ban" />&nbsp;
                            Cancelar
                </Button>
                        <Button className="button180" color="secondary" title="Limpar Campos">
                            <FontAwesomeIcon icon="eraser" />&nbsp;
                            Limpar
                </Button>
                        <Button className="button180" color="success" title="Criar Cliente" type="submit">
                            <FontAwesomeIcon icon="save" />&nbsp;
                            Criar Novo Cliente
                </Button>
                    </FormGroup>
                </Col>
            </Row>
        </form>
    );
}

export default UserRequesterFormNew;