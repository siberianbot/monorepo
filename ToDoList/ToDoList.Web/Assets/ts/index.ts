import * as React from 'react';
import * as ReactDOM from 'react-dom';

import {AppRoot} from "./AppRoot";

const appRootElement = document.getElementById("app-root");

ReactDOM.render(React.createElement(AppRoot), appRootElement);