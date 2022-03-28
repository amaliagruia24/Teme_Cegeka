import { useEffect, useState } from "react";
import { getCustomers } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import { Navigate, useNavigate } from "react-router-dom";
import Customer from "./Customer";


function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c));
    },[])
    
    let navigate = useNavigate();
    
    return (
    <div> 
        <h2>Customers</h2> 
        <div></div>
        <div className="container">
        <table className="table table-bordered">
            <thead className="table-dark">
                <tr>
                <th scope="col">Name</th>
                <th scope="col">Email</th>
                </tr>
            </thead>
            <tbody >
                {customers.map(c => <Customer customer={c} />)}    
            </tbody>
            </table>
        </div>
        <br></br>
        <button type="button" className="btn btn-primary btn-lg" onClick={() => navigate('/newcustomer')}>Add Customer</button>

    </div>);
}

export default Customers;