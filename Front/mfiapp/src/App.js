import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'

import { Container } from 'reactstrap'
import { library } from '@fortawesome/fontawesome-svg-core'
import {
  faBan,
  faCheck,
  faEraser,
  faReply,
  faSave,
  faQuestion,
  faTimes,
  faExclamation
} from '@fortawesome/free-solid-svg-icons'
import { faHandPointRight } from '@fortawesome/free-regular-svg-icons'

import DialogsContextProvider from './Contexts/Dialogs'

import HomePage from './Screens/Home/Page'
import NavBarTop from './Screens/Shared/Header/NavbarTop'
import PageNotFound from './Screens/Error/NotFound';
import UserTypeChoose from './Screens/User/Type/Choose'
import UserRequesterCreatePage from './Screens/User/Requester/Create';
import UserProviderCreatePage from './Screens/User/Provider/Create';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import BlockContextProvider from './Contexts/Block'

library.add(faBan, faCheck, faEraser, faHandPointRight, faReply, faSave, faQuestion, faTimes, faExclamation)

function App() {
  return (
    <div className="App">
      <BlockContextProvider>
        <DialogsContextProvider>
          <BrowserRouter>
            <NavBarTop />
            <Container>
              <Switch>
                <Route exact path="/" component={HomePage} />
                <Route path="/usuario/escolher" component={UserTypeChoose} />
                <Route path="/usuario/cliente/novo" component={UserRequesterCreatePage} />
                <Route path="/usuario/fornecedor/novo" component={UserProviderCreatePage} />
                <Route component={PageNotFound} />
              </Switch>
              <ToastContainer />
            </Container>
          </BrowserRouter>
        </DialogsContextProvider>
      </BlockContextProvider>
    </div >
  );
}

export default App;
