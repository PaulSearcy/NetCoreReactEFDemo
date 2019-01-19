import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { workers: [], loading: true };

    fetch('api/SampleData/Workers')
      .then(response => response.json())
      .then(data => {
        this.setState({ workers: data, loading: false });
      });
  }

    static renderWorkersTable(workers) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
                    <th>employeeId</th>
                    <th>firstName</th>
                    <th>lastName</th>
                    <th>manager</th>
                    <th>managerId</th>
                    <th>startDate</th>
                    <th>techLevel</th>
          </tr>
        </thead>
        <tbody>
                {workers.map(workers =>
                    <tr key={workers.employeeId}>
                        <td>{workers.employeeId}</td>
                        <td>{workers.firstName}</td>
                        <td>{workers.lastName}</td>
                        <td>{workers.manager}</td>
                        <td>{workers.managerId}</td>
                        <td>{workers.startDate}</td>
                        <td>{workers.techLevel}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderWorkersTable(this.state.workers);

    return (
      <div>
            <h1>workers</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
