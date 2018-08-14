import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './App';
import store from './store';
import { registerCommands } from './registerCommands';
import './index.css';

registerCommands(store, () => ReactDOM.render(<App />, document.getElementById('root') as HTMLElement));
