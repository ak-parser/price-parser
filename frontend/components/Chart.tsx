"use client";

import { PriceHistoryItem } from '@/types';
import React from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

const data = [
    {
        name: 'Page A',
        uv: 4000,
        pv: 2400,
        amt: 2400,
    },
    {
        name: 'Page B',
        uv: 3000,
        pv: 1398,
        amt: 2210,
    },
    {
        name: 'Page C',
        uv: 2000,
        pv: 9800,
        amt: 2290,
    },
    {
        name: 'Page D',
        uv: 2780,
        pv: 3908,
        amt: 2000,
    },
    {
        name: 'Page E',
        uv: 1890,
        pv: 4800,
        amt: 2181,
    },
    {
        name: 'Page F',
        uv: 2390,
        pv: 3800,
        amt: 2500,
    },
    {
        name: 'Page G',
        uv: 3490,
        pv: 4300,
        amt: 2100,
    },
];

type Props = {
    data: PriceHistoryItem[];
    currency: string;
};

type CustomTooltipProps = {
    active: any;
    payload: any;
    label: any;
};

const Chart = ({ data, currency }: Props) => {
    const CustomTooltip = ({ active, payload, label }: CustomTooltipProps) => {
        if (active && payload && payload.length) {
            return (
                <div className="custom-tooltip">
                    <p className="label">{`${label} : ${payload[0].value} ${currency}`}</p>
                </div>
            );
        }

        return null;
    };

    const chartData = data.map((x, i) => ({
        price: x.price,
        date: i === 0 || i === data.length - 1 ? undefined : x.date.toString().split("T")[1].split(":").splice(0, 2).join(":"),
    }));

    return (
        <LineChart
            width={550}
            height={300}
            data={chartData}
            margin={{
                top: 30,
                bottom: 40,
            }}
        >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="date" interval={chartData.length > 10 ? 1 : 0} />
            <YAxis dataKey="price" mirror />
            <Tooltip content={<CustomTooltip />} />
            <Line type="monotone" dataKey="price" stroke="#ff8b00" activeDot={{ r: 8 }} />
        </LineChart>
    );
}

export default Chart;
