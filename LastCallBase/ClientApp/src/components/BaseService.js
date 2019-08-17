import React, { Component } from 'react';

export class BaseService extends Component {
    displayName = BaseService.name

  constructor(props) {
    super(props);
      this.state = { localdata: [], loading: true };

      fetch('api/Sample/BaseService')
          .then(response => response.json())
          .then(data => {
              this.setState({ localdata: data, loading: false });
          })
          .catch((error) => { console.log("Request failed") });
  }

  static renderTable(thedata) {
    return (
      <table className='table'>
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
            </tr>
        </thead>
        <tbody>
                {thedata.map(d =>
                    <tr key={d.id}>
                        <td>{d.id}</td>
                        <td>{d.name}</td>
                    </tr>
          )}
        </tbody>
      </table>
    );
  }
     
    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : BaseService.renderTable(this.state.localdata);

      return (
        <div>
            <h1>Base Service Example</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    }

}

/*
 var url = 'https://example.com/profile';
var data = {username: 'example'};

fetch(url, {
  method: 'POST', // or 'PUT'
  body: JSON.stringify(data), // data can be `string` or {object}!
  headers:{
    'Content-Type': 'application/json'
  }
}).then(res => res.json())
.then(response => console.log('Success:', JSON.stringify(response)))
.catch(error => console.error('Error:', error));
 */
