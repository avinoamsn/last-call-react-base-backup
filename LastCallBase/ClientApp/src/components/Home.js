import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>Hello, Last Call!</h1>
        <p>Welcome to your base application, built with:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
        </ul>
        <p>To help you get started:</p>
        <ul>
          <li><strong>Client-side navigation</strong>. For example, click <em>Simple Demo</em> then <em>Back</em> to return here.</li>
          <li><strong>Acquiring data from the server</strong>. For example, click <em>Show Meal Offers</em> to see a sample fetch of data.</li>
          <li><strong>Sending data to the server</strong>. For example, click <em>Register Subscriber</em> to see a sample write of new data to the server.</li>
          <li><strong>Example service</strong>. Referenced in the documentation.</li>
        </ul>
        <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
      </div>
    );
  }
}
