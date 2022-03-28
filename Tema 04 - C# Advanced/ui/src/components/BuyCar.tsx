import { useEffect, useState } from 'react';
import {useLocation} from 'react-router-dom'
import { getCustomers, postOrder } from '../common/api.service';
import { CustomerModel } from '../models/customer.model';
import { OrderModel } from '../models/order.model';
import { useNavigate } from "react-router-dom";


function BuyCar () {

    const [customerId, setCustomerId] = useState(1)
    const [quantity, setQuantity] = useState(0)
    const [customers, setCustomers] = useState<CustomerModel[]>([])
    const {state} = useLocation()
    
    let checkQuantity = 0;
    let navigate = useNavigate();

    async function handleClick() {
        const order : OrderModel = {
            customerId,
            carOfferId: (state as any).id,
            quantity
        }

        let request = await postOrder(order);
        if(request == 400) {
            checkQuantity = 1;
        } 

    }

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c))
    },[])
    

    return(<>
    <h2>Buy car</h2>
    {
        checkQuantity?
        <div className="alert alert-primary d-flex align-items-center" role="alert">
            <svg className="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Info:"><use xlinkHref="#info-fill"/></svg>
            <div>
                Not enough cars of this model are available in stock!
            </div>
        </div> :
        <></>
    }
     <div>
                <div className="mb-3">
                    <label className="form-label">Customer</label>
                    <select className="form-control" placeholder="Name" onChange={ev => setCustomerId(Number(ev.target.value))}>
                        {customers.map(c => <option value={c.id}>{c.name}</option>)}
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Quantity</label>
                    <input type="number" className="form-control" placeholder="Quantity" onChange={ev => setQuantity(Number(ev.target.value))}/>
                </div>
                <a className="btn btn-primary" onClick={() => handleClick()}>Buy</a>
            </div>
    </>);
}

export default BuyCar