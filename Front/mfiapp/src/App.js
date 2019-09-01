import React from 'react';
import NavBarTop from './components/Pages/Header/NavbarTop';

import { library } from '@fortawesome/fontawesome-svg-core'
import { faCheck} from '@fortawesome/free-solid-svg-icons'

library.add(faCheck)

function App() {
  return (
    <div className="App">
      <NavBarTop />
    </div>
  );
}

export default App;
