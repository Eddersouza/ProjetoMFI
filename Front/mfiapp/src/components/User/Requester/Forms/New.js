import React, { useState, useContext } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { OpenToastSuccess } from '../../../../Functions/Toast/Message'
import { withRouter } from 'react-router-dom';

import Api from '../../../../Services/Api'

import {
    Button,
    FormGroup,
    Label,
    Input,
    Row,
    Col
} from 'reactstrap';
import { BlockContext } from '../../../../Contexts/Block';

const UserRequesterFormNew = (props) => {
    const [email, setEmail] = useState("")
    const [name, setName] = useState("")
    const [password, setPassword] = useState("")
    const [passwordConfirm, setPasswordConfirm] = useState("")

    const { blockPage, unBlockPage } = useContext(BlockContext)

    const clearFields = () => {
        setPassword('')
        setPasswordConfirm('')
        setEmail('')
        setName('')
    }

    const returnLastPage = () => {
        props.history.push('/');
    }

    const handleSubmit = (event) => {
        event.preventDefault()
        blockPage()
        const data = {
            Email: email,
            Name: name,
            Password: password
        }
        if (passwordConfirm === password) {
            Api.post('mfiapi/requester', data)
                .then(function (response) {
                    let successMessages = []
                    successMessages.push('Cliente cadastrado com Sucesso.')
                    OpenToastSuccess(successMessages)
                }).finally(function () {
                    unBlockPage()
                });
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <Row>
                <Col md={12}>
                    <FormGroup className="required">
                        <Label className='control-label' for="txtEmail">Email:</Label>
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
                    <FormGroup className="required">
                        <Label className='control-label' for="txtName">Nome</Label>
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
                    <FormGroup className="required">
                        <Label className='control-label' for="txtPassword">Senha</Label>
                        <Input id="txtPassword"
                            name="password"
                            onChange={e => setPassword(e.target.value)}
                            placeholder="Digite sua senha"
                            type="password"
                            value={password} />
                    </FormGroup>
                </Col>
                <Col md={6}>
                    <FormGroup className="required">
                        <Label className='control-label' for="txtPassword">Confirme a Senha</Label>
                        <Input className={passwordConfirm !== password ? 'field-with-error' : ''}
                            id="txtPasswordConfirm"
                            name="passwordConfirm"
                            onChange={e => setPasswordConfirm(e.target.value)}
                            placeholder="Digite sua senha"
                            type="password"
                            value={passwordConfirm} />
                        {(passwordConfirm !== password)
                            ? <label className='obs-field'> Este campo deve ser igual ao campo senha.</label>
                            : null}
                    </FormGroup>
                </Col>
            </Row>
            <Row>
                <Col md={12}>
                    <FormGroup>
                        <Button className="button180" color="danger" onClick={returnLastPage}
                            title="Cancelar Criação de Cliente">
                            <FontAwesomeIcon icon="ban" />&nbsp;
                            Cancelar
                </Button>
                        <Button className="button180"
                            color="secondary"
                            onClick={clearFields}
                            title="Limpar Campos"
                            type='button'>
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

export default withRouter(UserRequesterFormNew)