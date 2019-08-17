import React, { Component } from 'react';

export class FetchSubscriberAndPreferences extends Component {
    displayName = FetchSubscriberAndPreferences.name

  constructor(props) {
    super(props);
    this.state = { person: null, loading: true };
      this.renderData = this.renderData.bind(this);

      fetch('api/Sample/FetchSubscriberAndPreferences')
      .then(response => response.json())
      .then(data => {
        this.setState({ person: data, loading: false });
      });
  }

  renderData(person) {
      return (
          <div>
            <p>Subscriber ID: {person.id}</p>
            <p>Subscriber username: {person.email}</p>
            <p>Subscriber phone #: {person.phone}</p>
              <p>Subscriber friendly name: {person.friendlyname}</p>
              <p>On mailing list? {person.onmailinglist > 0 && <span>Yes</span>} {person.onmailinglist===0 && <span>No</span>} </p>
              <p>Text offers? {person.textoffers > 0 && <span>Yes</span>} {person.textoffers === 0 && <span>No</span>}</p>
              <p>Email offers? {person.emailoffers > 0 && <span>Yes</span>} {person.emailoffers === 0 && <span>No</span>}</p>
              <p>Preferred delivery address: {person.deliveryaddress}</p>
              <table className='table'>
                <thead>
                    <tr>
                        <th width='10%'>Preference Type ID</th>
                          <th width='20%'>Preference Name</th>
                          <th width='70%'/>
                    </tr>
                </thead>
                <tbody>
                {person.preferences.map(p =>
                    <tr key={p.id}>
                        <td>{p.preftype}</td>
                                  <td>{p.prefname}</td>
                                  <td></td>
                    </tr>
                  )}
                </tbody>
                      </table>
           </div>
    );
  }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : this.renderData(this.state.person);

      return (
        <div>
            <h1>Subscriber and Food Preferences</h1>
            <p>This component demonstrates fetching a complex object from the server</p>
            {contents}
        </div>
    );
    }

}
