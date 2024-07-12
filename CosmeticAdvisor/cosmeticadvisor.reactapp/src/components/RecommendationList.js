import React, { useState, useEffect } from 'react';
import axios from 'axios';

const RecommendationList = () => {
    const [recommendations, setRecommendations] = useState([]);

    useEffect(() => {
        axios.get('/api/recommendations')
            .then(response => setRecommendations(response.data))
            .catch(error => console.error('Error fetching recommendations:', error));
    }, []);

    return (
        <div>
            <h1>Recommendation List</h1>
            <ul>
                {recommendations.map(recommendation => (
                    <li key={recommendation.recommendationId}>{recommendation.notes}</li>
                ))}
            </ul>
        </div>
    );
};

export default RecommendationList;
