import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}

export function postCar(car: CarModel) {
    fetch('https://localhost:7198/CarOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
}

export function getCustomers(): Promise<CustomerModel[]> {
    return fetch('https://localhost:7198/api/Customer')
        .then(r => r.json())
}

export function postCustomer(customer: CustomerModel) {
    fetch('https://localhost:7198/api/Customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
}

export async function postOrder(order: OrderModel): Promise<any> {
    return fetch('https://localhost:7198/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(order)
    }).then(response => response.json())
    .then(data => data.status);
}