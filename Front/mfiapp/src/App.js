import React from 'react';

import { Container } from 'reactstrap'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCheck } from '@fortawesome/free-solid-svg-icons'
import { faHandPointRight } from '@fortawesome/free-regular-svg-icons'

import NavBarTop from './Screens/Shared/Header/NavbarTop';
import UserTypeChoose from './Screens/User/Type/Choose';

library.add(faCheck, faHandPointRight)

function App() {
  return (
    <div className="App">
      <NavBarTop />
      <Container>
        <UserTypeChoose />
      </Container>
    </div>
  );
}

export default App;
