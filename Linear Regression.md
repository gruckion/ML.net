Linear regression model to predict house prices using house size as the feature.

Linear regression simply relates an independent variable to a dependant variable to the dependant variable.
In other words `y(x)` the relationship could be positive `y increase with x`, or negative `y decreases with x`.

The linear regression algorithm is based on the [least squares approximation](https://en.wikipedia.org/wiki/Least_squares).
When a system of equations has more equations than unknowns then the unknowns cannot be solved for exactly. Consider the following data.

|           | 1   | 2   | 3   | 4   | 5   | 6   | 7  | 8   |
|-----------|-----|-----|-----|-----|-----|-----|----|-----|
| Height, x | 65  | 65  | 62  | 67  | 69  | 65  | 61 | 67  |
| Weight, y | 105 | 125 | 110 | 120 | 140 | 135 | 95 | 130 |

In this case we want to find a line that best finds the data, the criterion being the least squares method.

<img src="linear model.png" />

> Our initial linear model is the red line, chosen at random, and we want to go to the bottom red line.


1. Draw any line as our initial linear model.
2. First we measure the vertical distance between the point and the linear model line.
3. Then we take the vertical distance and square it, we don't care if it is above or below and squaring removes this detail. Namely $d_1^2 = (-d_1)^2$.
4. We then take the sum of all the squared distances $D = d_1^2 + d_2^2 + d_3^2 + ... + d_n^2$.
5. The best linear model will have the smallest value for `D`

Points to note, if we minimize little `d` we will only produce a straight line that satisfies a single point. However if we minimize `D` we can satisfy the total distance for all points.

Actually calculating the arithmetic for the above table of data. All we are doing here is the straight line equation $y = mx + c$ or in statistics $\hat{y} + b_0 + b_1x$, the hat indicates that this is an approximate model.

We need $b_0$ the y intercept, in the picture this is `5` and $b_1$ which is $\frac{1}{10}$ think of it as the $\frac{up}{across}$.

To calculate the slope of the line $b_1$ we can use, proof not provided.

$$
    b_1 = \frac{\sum{ (x-\bar{x})(y-\bar{y}) }}{\sum{(x-\bar{x})^2}} = \frac{\sum{xy}-\frac{\sum x \sum y}{n}}{\sum x^2 - \frac{(\sum(x))^2}{n}}
$$

Then to calculate the intercept $b_0$ we use;

$$
    b_0 = \frac{\sum(y) - (b_i . \sum(x))}{n} = \bar{y} - b_1\bar{x}
$$

Where `n` is the number of points. So this is a lot of algebra.