import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './App';
import './index.css';
// import store from './store';
// import { signalRRegisterCommands } from './actions/user';

// signalRRegisterCommands(store, () => ReactDOM.render(<App />, document.getElementById('root') as HTMLElement));

ReactDOM.render(<App />, document.getElementById('root') as HTMLElement);
