import React, { Component } from 'react';
import { Link } from "react-router-dom";
import CustomerDataService from "../services/customer.service";
import "bootstrap/dist/css/bootstrap.min.css";

export class CustomerDetail extends Component {
    static displayName = CustomerDetail.companyName;

    constructor(props) {
        super(props);
        this.populateCustomerData = this.populateCustomerData.bind(this);
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeCity = this.onChangeCity.bind(this);
        this.state = {
            id: 0,
            customer: {},
            loading: true
        };
    }

    componentDidMount() {
        let id = this.props.match.params.id;
        this.populateCustomerData(id);
    }

    static renderCustomer(customer) {
        return (
            <form>
                <div className="form-group">
                    <label htmlFor="title">Company Name</label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        value={customer.companyName}
                        onChange={ this.onChangeName }
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="title">City</label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        value={customer.city?.cityName}
                        onChange={ this.onChangeCity}
                    />
                </div>
                <div className="row">
                    {customer.customerID <= 0 ? (
                        <button
                            className="badge badge-primary mr-2"
                            onClick={() => this.newCustomer(false)}
                        >
                            New
                        </button>
                    ) : (
                            <button type="submit"
                                className="badge badge-primary mr-2"
                                onClick={this.updateCustomer}
                            >
                                Update
                            </button>)}
                    <Link to={"/customer/" } className="badge badge-primary">Cancel</Link>
                    <p>{this.state?.message}</p>
                </div>
            </form>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CustomerDetail.renderCustomer(this.state.customer);

        return (
            <div>
                <h1 id="tabelLabel" >Customer Detail</h1>
                {contents}
            </div>
        );
    }

    async populateCustomerData(id) {
        if (id >= 0) {
            CustomerDataService.get(id)
                .then(response => {
                    this.setState({ customer: response.data, loading: false });
                })
        }
        else {
            this.setState({
                customer: {
                    customerID: 0,
                    companyName: "",
                    address1: "",
                    address2: "",
                    cityID: null,
                    city: {cityID: null, cityName: ""},
                    postalCode: "",
                    contactName: "",
                    contactPhone: "",
                    contactEmail: ""
                }, loading: false
            })
        }
    }

    onChangeName(e) {

    }
    onChangeCity(e) {

    }
}
