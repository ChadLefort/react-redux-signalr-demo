import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './App';
import store from './store';
import { signalRRegisterCommands } from './actions/counter';
import './index.css';

signalRRegisterCommands(store, () => ReactDOM.render(<App />, document.getElementById('root') as HTMLElement));
