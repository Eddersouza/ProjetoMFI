import React from 'react';
import ProviderCard from './Card';

const ListProviderCard = () => {

    let list = []
    let objtemp = { name: 'Teste' }

    for (let index = 0; index < 20; index++) {
        list.push(objtemp)
    }

    return (
        <div>
            {list.map(card => {
                return (
                    <>
                        <ProviderCard />
                        <br />
                    </>)
            })}
        </div>);
}

export default ListProviderCard;