import React, { Component } from 'react';
import { Link } from "react-router-dom";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello!</h1>
            <p>Welcome to Lifeline Sample App</p>
            <Link to={"/customer/"} className="badge badge-primary">Link to Customer List</Link>
      </div>
    );
  }
}
