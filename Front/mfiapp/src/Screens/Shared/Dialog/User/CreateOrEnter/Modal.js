import React, { useContext } from 'react';

import {
    Modal,
    ModalHeader,
    ModalBody,
    Row,
    Col
} from 'reactstrap';

import AreaDialogCreateUser from './CreateUser';
import AreaDialogEnterSystem from './EnterSystem';
import { DialogsContext } from '../../../../../Contexts/Dialogs';

const DialogUserCreateOrEnter = () => {
    const { dialogEnterOrCreateOpen, toggleDialogEnterOrCreate } = useContext(DialogsContext)
    return (
        <Modal backdrop='static' className='primary' isOpen={dialogEnterOrCreateOpen}
            toggle={toggleDialogEnterOrCreate} style={{ maxWidth: '70%' }}>
            <ModalHeader toggle={toggleDialogEnterOrCreate}>O que voce deseja?</ModalHeader>
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