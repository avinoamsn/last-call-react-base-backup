import React, { Component } from 'react';

export class PostService extends Component {
    displayName = PostService.name

    constructor(properties) {
        super(properties);
            // The 'state' for this screen are the two fields we want to collect plus a standard error object.
        this.state = {
            username: '',
            password: '',
            errorInfo: { errorCode: 0, errorMessage: '', errorDescription: '', statusMessage: '' }  // Standard server error object
        };

            // Good luck figuring out which 'this' this is! But React uses a construct like this everywhere.
        this.handleInputChange = this.handleInputChange.bind(this);
    }

        // This will be called every time the user types something in the username or password fields.
    handleInputChange(event) {
        const name = event.target.name;
        const value = event.target.value;

        this.setState({[name]: value });    // Sets state property, for example username: 'adrian' 
    }

    sendForm() {
        var url = 'api/Sample/PostService';                 // The service URL
        var formData = new FormData();
        formData.append('username', this.state.username);   // Add the two fields from the screen
        formData.append('password', this.state.password);

            // POST the data, and check the response
        fetch(url, {
            method: 'POST',
            body: formData
        }).then(response => response.json())
            .then(data => {
                // Set the standard error return object
              this.setState({ errorInfo: data });
                // These lines are simply illustrative of how to get some debug messaging
              console.log(this.state.errorInfo.errorCode);
              console.log(this.state.errorInfo.errorMessage);
              console.log(this.state.errorInfo.errorDescription);
              console.log(this.state.errorInfo.statusMessage);
                // Check for an error
              if (this.state.errorInfo.errorCode !== 0) {
                  let x = { message: 'Failed login: ' + this.state.errorInfo.errorMessage }
                  throw x;
              }
          })
          .catch(e => console.error(e.message));
    }

    render() {
            // The HTML for this form plus the binding to the functions in the current object
        return (
          <div>
                <h1>Post Service Example</h1>
                <p>This component demonstrates sending data to the server.</p>
                <form>
                    <p>Username: <input type='text' name='username' id='username' onChange={this.handleInputChange}/></p>
                    <p>Password: <input type='password' name='password' id='password' onChange={this.handleInputChange}/></p>
                    <button onClick={this.sendForm.bind(this)}>Send the data</button>
                </form>
           </div>
        );
    }
}

