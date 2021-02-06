import React, { Component } from 'react';
import CustomerDataService from "../services/customer.service";
import { Link } from "react-router-dom";

export class Customer extends Component {
  static displayName = Customer.name;

  constructor(props) {
      super(props);
      this.deleteCustomer = this.deleteCustomer.bind(this);

      this.state = {
          customers: [],
          loading: true,
          message: String
      };
  }

  componentDidMount() {
      this.populateCustomerData();
  }

    static renderCustomersTable(customers) {
        return (
            <div>
              <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                  <tr>
                    <th>Company Name</th>
                    <th>Address 1</th>
                    <th>Email</th>
                            <th>Contact Name</th>
                            <th></th>
                  </tr>
                </thead>
                <tbody>
                  {customers.map(customer =>
                    <tr key={customer.customerID}>
                        <td>{customer.companyName}</td>
                        <td>{customer.address1}</td>
                        <td>{customer.contactEmail}</td>
                        <td>{customer.contactName}</td>
                          <td><Link to={"/customer-detail/" + customer.customerID} className="badge badge-primary">Edit</Link>
                              <button className="badge badge-warning mr-2" value={customer.customerID}
                                  onClick={this.deleteCustomer}>Delete</button>
                          </td>
                    </tr>
                  )}
                </tbody>
                </table>
                <Link to={"/customer-detail/" + 0}
                    className="badge badge-warning">New</Link>
                <div>{ this.state?.message }</div>
                </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Customer.renderCustomersTable(this.state.customers);

    return (
      <div>
        <h1 id="tabelLabel" >Customers</h1>
        {contents}
      </div>
    );
  }

  async populateCustomerData() {
      CustomerDataService.getAll()
          .then(response => {
                this.setState({ customers: response.data, loading: false });
          })
    }

   async deleteCustomer(e) {
       let id = e;
       CustomerDataService.delete(id)
           .then(response => {
               if (response.data) {
                    this.state.setState("message", "customer deleted.");
                    }
           })
    }
}
