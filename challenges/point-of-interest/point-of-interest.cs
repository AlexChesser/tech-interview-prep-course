using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
Given a geolocation ( longitude / latitude). Find at least k=3 closest points of interest near the geolocation.

POI Locations: 
    {
        {148.02, -31.16},
        {148.06, -30.96},
        {148.06, -31.72}, // 92
        {148.06, -31.86}, // 37
        {148.07, -30.27},
        {148.08, -31.57}, 
        {148.08, -31.45},
        {148.86, -30.47},
        {148.91, -30.27}, 
        {148.94, -31.83}, // 60
        {148.11, -31.01}
    }

Ratings: {89,51,92,37,65,67,33,72,82,60,43}

Start location loc: {148.7, -31.9}
*/

class Solution {

    static List<double[]> distances = new List<double[]> {
        new double[] {148.02, -31.16},
        new double[] {148.02, -31.16},
        new double[] {148.02, -31.16},
        new double[] {148.06, -30.96},
        new double[] {148.06, -31.72}, 
        new double[] {148.06, -31.86},
        new double[] {148.07, -30.27},
        new double[] {148.08, -31.57}, 
        new double[] {148.08, -31.45},
        new double[] {148.86, -30.47},
        new double[] {148.91, -30.27}, 
        new double[] {148.94, -31.83}, 
        new double[] {148.11, -31.01}
    };
    
    static List<int> ratings = new List<int> {89,87,86,51,92,37,65,67,33,72,82,60,43};

    static double getDistance(double x1, double x2, double y1, double y2){
        //  d=√((x_2-x_1)²+(y_2-y_1)²) 
        return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1),2));
    }

    public class POIDetails {
        public double distance { get; set; }
        public int rating { get; set; }
    }

    static List<POIDetails> findNearest(double lat, double lng) {
        // a = lat - distances[i][0] 
        // b = lng - distances[i][1] 
        // distance = a + b
        List<POIDetails> poi_details = new List<POIDetails>();
        for(int i = 0; i < distances.Count; i++)
        {
            // get the drviver details value
            // compare against the 3 previous max values
            // throw away if not greater than. 
            poi_details.Add(new POIDetails {
                distance = getDistance(distances[i][0], lat, distances[i][1], lng),
                rating = ratings[i]
            });
            // if the distance isn't in the top three throw it away. 
        }
        return poi_details
            .OrderBy(dd => dd.distance)
            .ThenByDescending(dd => dd.rating)
            .Take(3)
            .ToList();
    }

    static void Main(String[] args) {
        double val1 = 148.02;
        double val2 = -31.16;
        List<POIDetails> nearest = findNearest(val1, val2);
        Console.WriteLine(string.Join(",", nearest.Select(x => x.rating).ToList()));
    }
}      
