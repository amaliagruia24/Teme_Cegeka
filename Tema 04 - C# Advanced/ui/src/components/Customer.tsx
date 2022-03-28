import { CustomerModel } from "../models/customer.model";

interface TProps{
    customer: CustomerModel;
}

function Customer(props: TProps){
    const {customer} = props

    return (<tr>
        <td>{props.customer.name}</td>
        <td>{props.customer.email}</td>
    </tr>)
}

export default Customer;