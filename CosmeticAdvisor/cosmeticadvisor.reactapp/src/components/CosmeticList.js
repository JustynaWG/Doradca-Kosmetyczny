import React, { useState, useEffect } from 'react';
import axios from 'axios';

const CosmeticList = () => {
    const [cosmetics, setCosmetics] = useState([]);

    useEffect(() => {
        axios.get('/api/cosmetics')
            .then(response => setCosmetics(response.data))
            .catch(error => console.error('Error fetching cosmetics:', error));
    }, []);

    return (
        <div>
            <h1>Cosmetic List</h1>
            <ul>
                {cosmetics.map(cosmetic => (
                    <li key={cosmetic.cosmeticId}>{cosmetic.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default CosmeticList;
