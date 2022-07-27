import React from "react";

import { BrowserRouter, Route, Switch } from "react-router-dom/cjs/react-router-dom";


import Votes from "./pages/Votes";
import Vote from "./pages/Vote";
import NewCandidate from "./pages/NewCandidate";
export default function Routes(){

    return (
        <BrowserRouter>
            <Switch>
                <Route path ="/votes" exact component = {Votes}/>
                <Route path ="/vote" exact component = {Vote}/>
                <Route path = "/candidate" exact component = {NewCandidate}/>
            </Switch>
        </BrowserRouter>
        );
}