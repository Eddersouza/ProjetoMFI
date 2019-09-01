import React from 'react';
import {
    Modal,
    ModalHeader,
    ModalBody,
    Row,
    Col
} from 'reactstrap';

import AreaDialogCreateUser from './CreateUser';
import AreaDialogEnterSystem from './EnterSystem';

const DialogUserCreateOrEnter = (props) => {
    return (
        <Modal isOpen={props.modalOpen} toggle={props.toggle} className='primary' backdrop='static' style={{ maxWidth: '70%' }}>
            <ModalHeader toggle={props.toggle}>O que voce deseja?</ModalHeader>
            <ModalBody>
                <Row>
                    <Col md={6} sm={12}>
                        <AreaDialogEnterSystem />
                    </Col>
                    <Col md={6} sm={12}>
                        <AreaDialogCreateUser />
                    </Col>
                </Row>
            </ModalBody>
        </Modal>
    );
}

export default DialogUserCreateOrEnter;