import React from 'react'
import {
  Card,
  CardBody,
  Row,
  Col
} from 'reactstrap'
import UserTypeChooseProvider from './ChooseProvider'
import UserTypeChooseRequester from './ChooseRequester';

const UserTypeChoose = () => {
  return (
    <div>
      <br />
      <Card>
        <CardBody>
          <Row>
            <p className=" col-12 text-center">
              Olá seja bem vindo(a) o que você deseja fazer?
              </p>
          </Row>
          <Row>
            <Col md={6} sm={12} >
              <UserTypeChooseRequester />
            </Col>
            <Col md={6} sm={12} >
              <UserTypeChooseProvider />
            </Col>
          </Row>
        </CardBody>
      </Card>
    </div>
  );
}

export default UserTypeChoose;
