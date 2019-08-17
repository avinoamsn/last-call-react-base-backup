import React, { Component } from 'react';

export class RegisterSupplier extends Component {
    displayName = RegisterSupplier.name

  constructor(props) {
    super(props);
    this.state = { meals: [], loading: true };
    //this.claimMeal = this.claimMeal.bind(this);

    fetch('api/Suppliers/RegisterSupplier')
      .then(response => response.json())
      .then(data => {
        this.setState({ meals: data, loading: false });
      });
  }

  static claimMeal(id) {
      alert("You have claimed a meal with ID# " + id);
  }

  static renderOffersTable(meals) {
    return (
      <table className='table'>
        <thead>
            <tr>
                <th>Date</th>
                <th>Meal Name</th>
                <th>Meal Type</th>
                <th>Price</th>
                <th>Supplier</th>
                <th>Available</th>
                <th>Details</th>
            </tr>
        </thead>
        <tbody>
        {meals.map(meal =>
            <tr key={meal.id}>
                <td>{meal.dateFormatted}</td>
                <td>{meal.mealName}</td>
                <td>{meal.foodType}</td>
                <td>${meal.priceDollars}.{meal.priceCents}</td>
                <td>{meal.mealSupplier}</td>
                <td>{meal.qtyAvailable}</td>
                <td>{meal.mealDetails}</td>
                <td><button onClick={this.claimMeal.bind(this, meal.id)}>Claim</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
     
    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : RegisterSupplier.renderOffersTable(this.state.meals);

      return (
        <div>
            <h1>Meal Offers</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    }

}
