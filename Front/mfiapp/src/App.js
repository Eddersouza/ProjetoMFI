import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'

import { Container } from 'reactstrap'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCheck } from '@fortawesome/free-solid-svg-icons'
import { faHandPointRight } from '@fortawesome/free-regular-svg-icons'

import DialogsContextProvider from './Contexts/Dialogs'

import HomePage from './Screens/Home/Page'
import NavBarTop from './Screens/Shared/Header/NavbarTop'
import PageNotFound from './Screens/Error/NotFound';
import UserTypeChoose from './Screens/User/Type/Choose'

library.add(faCheck, faHandPointRight)

function App() {
  return (
    <div className="App">
      <DialogsContextProvider>
        <BrowserRouter>
          <NavBarTop />
          <Container>
            <Switch>
              <Route exact path="/" component={HomePage} />
              <Route path="/Usuario/Escoher" component={UserTypeChoose} />
              <Route component={PageNotFound} />
            </Switch>
          </Container>
        </BrowserRouter>
      </DialogsContextProvider>
    </div >
  );
}

export default App;
