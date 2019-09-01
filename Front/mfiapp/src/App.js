import React from 'react';

import { library } from '@fortawesome/fontawesome-svg-core'
import { faCheck} from '@fortawesome/free-solid-svg-icons'

import NavBarTop from './Screens/Shared/Header/NavbarTop';

library.add(faCheck)

function App() {
  return (
    <div className="App">
      <NavBarTop />
    </div>
  );
}

export default App;
