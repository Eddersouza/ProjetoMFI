import React from 'react';
import {
    Button,  
    Form,
    FormGroup,
    Label,
    Input,
} from 'reactstrap';

const AreaDialogEnterSystem = () => {
    return (
        <>
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
                    <Button className="btn btn-success btn-block">Entrar</Button>
                    {/* <a href="/forgot/" className="btn btn-default btn-block">Esqueci a senha</a> */}
                </Form>
            </div>
        </>
    );
}

export default AreaDialogEnterSystem;